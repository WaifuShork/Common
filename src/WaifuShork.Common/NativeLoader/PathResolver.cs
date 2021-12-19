namespace WaifuShork.Common.NativeLoader
{
	using System;
	using System.IO;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Microsoft.Extensions.DependencyModel;

	public abstract class PathResolver
	{
		public abstract IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name);
		public static PathResolver Default { get; } = new DefaultPathResolver();
	}
	
	public class DefaultPathResolver : PathResolver
	{
		public override IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name)
		{
			if (!string.IsNullOrWhiteSpace(AppContext.BaseDirectory))
			{
				yield return Path.Combine(AppContext.BaseDirectory, name);
			}

			yield return name;

			if (TryLocateNativeAssetFromDeps(name, out var app, out var deps))
			{
				yield return app;
				yield return deps;
			}
		}

		private bool TryLocateNativeAssetFromDeps(string name, out string appLocalNativePath, out string depsResolvedPath)
		{
			var defaultContext = DependencyContext.Default;
			if (defaultContext == null)
			{
				appLocalNativePath = null;
				depsResolvedPath = null;
				return false;
			}

			var currentRID = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.GetRuntimeIdentifier();
			var allRIDs = new List<string>();
			allRIDs.Add(currentRID);

			if (!AddFallbacks(allRIDs, currentRID, defaultContext.RuntimeGraph))
			{
				var guessedFallbackRID = GuessFallbackRID(currentRID);
				if (guessedFallbackRID != null)
				{
					allRIDs.Add(guessedFallbackRID);
					AddFallbacks(allRIDs, guessedFallbackRID, defaultContext.RuntimeGraph);
				}
			}

			foreach (var rid in allRIDs)
			{
				foreach (var runtimeLib in defaultContext.RuntimeLibraries)
				{
					foreach (var nativeAsset in runtimeLib.GetRuntimeNativeAssets(defaultContext, rid))
					{
						if (Path.GetFileName(nativeAsset) == name || Path.GetFileNameWithoutExtension(nativeAsset) == name)
						{
							appLocalNativePath = Path.Combine(AppContext.BaseDirectory, nativeAsset);
							appLocalNativePath = Path.GetFullPath(appLocalNativePath);

							depsResolvedPath = Path.Combine(GetNugetPackagesRootDirectory(), runtimeLib.Name.ToLowerInvariant(), runtimeLib.Version, nativeAsset);
							depsResolvedPath = Path.GetFullPath(depsResolvedPath);
							return true;
						}
					}
				}
			}

			appLocalNativePath = null;
			depsResolvedPath = null;
			return false;
		}

		private string GuessFallbackRID(string actualRuntimeIdentifier)
		{
			if (actualRuntimeIdentifier == "osx.10.13-x64")
			{
				return "osx.10.13-x64";
			}
			if (actualRuntimeIdentifier.StartsWith("osx"))
			{
				return "osx-x64";
			}

			return null;
		}

		private bool AddFallbacks(List<string> fallbacks, string rid, IEnumerable<RuntimeFallbacks> allFallbacks)
		{
			foreach (var fb in allFallbacks)
			{
				if (fb.Runtime == rid)
				{
					fallbacks.AddRange(fb.Fallbacks);
					return true;
				}
			}

			return false;
		}

		private string GetNugetPackagesRootDirectory()
		{
			return Path.Combine(GetUserDirectory(), ".nuget", "packages");
		}

		private string GetUserDirectory()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return Environment.GetEnvironmentVariable("USERPROFILE");
			}
			
			return Environment.GetEnvironmentVariable("HOME");
		}
	}
}