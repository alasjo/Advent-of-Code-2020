using System;
using System.Collections.Generic;
using System.Text;
using AoC2020ClassLibrary;

namespace AoC2020Days
{
    public class Day8 : Day
    {
        Accumulator acc;
        public Day8(string path) : base(8)
        {
            FileParser parser = new FileParser(path);
            acc = Accumulator.Setup(parser.Lines);
        }

        public override int Part1()
        {
            return acc.Run();
        }

        public override int Part2()
        {
            int result = 0;
            
            for (int i = 0; i < acc.GetInstructions.Count; i++)
            {
                int temp = 0;
                if (
                    (acc.GetInstructions[i].Opcode == Opcode.Nop && acc.GetInstructions[i].Offset != 0)
                    || acc.GetInstructions[i].Opcode == Opcode.Jmp
                )
                {
                    acc.FlipInstruction(i);
                    temp = acc.Run();
                    if (acc.State == State.Terminated)
                    {
                        result = temp;
                        break;
                    }
                    acc.FlipInstruction(i);
                }
            }

            return result;
        }
    }
}
