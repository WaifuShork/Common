using System;

namespace WaifuShork.Common;

	public class ConsoleProgressBar : IDisposable
    {
        private const char ProgressBlockCharacter = ' ';
        private readonly float _unitsOfWorkPerProgressBlock;
        private readonly bool _originalCursorVisible;

        public ConsoleColor CompletedColor { get; private set; }
        public ConsoleColor RemainingColor { get; private set; }
        public int StartingPosition { get; private set; }
        public uint WidthInCharacters { get; private set; }
        public uint TotalUnitsOfWork { get; private set; }

        public ConsoleProgressBar(
            uint totalUnitsOfWork,
            int startingPosition = 0,
            uint widthInCharacters = 40,
            ConsoleColor completedColor = ConsoleColor.Cyan,
            ConsoleColor remainingColor = ConsoleColor.Black)
        {
            TotalUnitsOfWork = totalUnitsOfWork;
            StartingPosition = startingPosition;
            WidthInCharacters = widthInCharacters;
            CompletedColor = completedColor;
            RemainingColor = remainingColor;

            _unitsOfWorkPerProgressBlock = (float) TotalUnitsOfWork / WidthInCharacters;
            _originalCursorVisible = Console.CursorVisible;
        }

        public void Draw(uint currentUnitOfWork)
        {
            if (currentUnitOfWork > TotalUnitsOfWork)
            {
                throw new ArgumentOutOfRangeException(nameof(currentUnitOfWork), "currentUnitOfWork must be less than TotalUnitsOfWork");
            }

            var originalBackgroundColor = Console.BackgroundColor;
            Console.CursorVisible = false;
            Console.CursorLeft = StartingPosition;

            try
            {
                var completeProgressBlocks = (uint) Math.Round(currentUnitOfWork / _unitsOfWorkPerProgressBlock);
                WriteCompletedProgressBlocks(completeProgressBlocks);
                WriteRemainingProgressBlocks(completeProgressBlocks);

                var percentComplete = (float) currentUnitOfWork / TotalUnitsOfWork * 100;
                WriteProgressText(currentUnitOfWork, percentComplete, originalBackgroundColor);

                if (currentUnitOfWork == TotalUnitsOfWork)
                {
                    Console.WriteLine();
                }
            }
            finally
            {
                Console.BackgroundColor = originalBackgroundColor;
            }
        }

        private void WriteCompletedProgressBlocks(uint completeProgressBlocks)
        {
            Console.BackgroundColor = CompletedColor;
            for (var i = 0; i < completeProgressBlocks; ++i)
            {
                Console.Write(ProgressBlockCharacter);
            }
        }

        private void WriteRemainingProgressBlocks(uint completeProgressBlocks)
        {
            Console.BackgroundColor = RemainingColor;
            for (var i = completeProgressBlocks; i < WidthInCharacters; ++i)
            {
                Console.Write(ProgressBlockCharacter);
            }
        }

        private void WriteProgressText(uint currentUnitOfWork, float percentComplete, ConsoleColor originalBackgroundColor)
        {
            Console.BackgroundColor = originalBackgroundColor;
            Console.Write(" {0,5}% ({1} of {2})", percentComplete.ToString("n2"), currentUnitOfWork, TotalUnitsOfWork);
        }

        public void Dispose()
        {
            Console.CursorVisible = _originalCursorVisible;
        }
    }

/*public class ProgressBar : IDisposable, IProgress<double>
{
	private readonly object m_lock = new();
	private const int BlockCount = 10;
	private const char BlockSymbol = '#'; 
	private readonly TimeSpan m_animationInterval = TimeSpan.FromSeconds(1.0 / 8);
	private const string m_animation = @"|/-\";

	private readonly Timer m_timer;

	private double m_currentProgress;
	private string m_currentText = string.Empty;
	private bool m_disposed;
	private int m_animationIndex;

	public ProgressBar() 
	{
		m_timer = new Timer(TimerHandler);

		if (!Console.IsOutputRedirected)
		{
			ResetTimer();
		}
	}

	public void Report(double value) 
	{
		value = Math.Max(0, Math.Min(1, value));
		Interlocked.Exchange(ref m_currentProgress, value);
	}

	private void TimerHandler(object? state) 
	{
		lock (m_lock) 
		{
			if (m_disposed)
			{
				return;
			}

			var progressBlockCount = (int) (m_currentProgress * BlockCount);
			var percent = (int) (m_currentProgress * 100);

			var progressBlock = new string(BlockSymbol, progressBlockCount);
			var progressBar = new string('-', BlockCount - progressBlockCount);
			var animationIndex = m_animation[m_animationIndex++ % m_animation.Length];
			
			var text = $"[{progressBlock}{progressBar}] {percent,3}% {animationIndex}";
			UpdateText(text);

			ResetTimer();
		}
	}

	private void UpdateText(string text) 
	{
		// Get length of common portion
		var commonPrefixLength = 0;
		var commonLength = Math.Min(m_currentText.Length, text.Length);
		while (commonPrefixLength < commonLength && text[commonPrefixLength] == m_currentText[commonPrefixLength]) {
			commonPrefixLength++;
		}

		// Backtrack to the first differing character
		var outputBuilder = new StringBuilder();
		outputBuilder.Append('\b', m_currentText.Length - commonPrefixLength);

		// Output new suffix
		outputBuilder.Append(text[commonPrefixLength..]);

		// If the new text is shorter than the old one: delete overlapping characters
		var overlapCount = m_currentText.Length - text.Length;
		if (overlapCount > 0) {
			outputBuilder.Append(' ', overlapCount);
			outputBuilder.Append('\b', overlapCount);
		}

		Console.Write(outputBuilder);
		m_currentText = text;
	}

	private void ResetTimer()
	{
		lock (m_lock)
		{
			m_timer.Change(m_animationInterval, TimeSpan.FromMilliseconds(-1));
		}
	}

	public void Dispose() 
	{
		lock (m_lock) 
		{
			m_disposed = true;
			UpdateText(string.Empty);
			m_timer.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}*/