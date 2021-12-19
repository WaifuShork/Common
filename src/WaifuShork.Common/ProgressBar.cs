using System;
using System.Runtime.Versioning;

namespace WaifuShork.Common;

[SupportedOSPlatform("windows")]
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
            var completeProgressBlocks = (uint) System.Math.Round(currentUnitOfWork / _unitsOfWorkPerProgressBlock);
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
        Console.Write($" {percentComplete,5:n2}% ({currentUnitOfWork} of {TotalUnitsOfWork})");
    }

    public void Dispose()
    {
        Console.CursorVisible = _originalCursorVisible;
        GC.SuppressFinalize(this);
    }
}