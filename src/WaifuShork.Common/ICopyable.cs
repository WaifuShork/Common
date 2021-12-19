namespace WaifuShork.Common;

public interface ICopyable<out T>
{
	T Copy();
}