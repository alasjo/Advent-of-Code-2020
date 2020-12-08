using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class Accumulator
    {
        private List<Instruction> instructions;
        private int accumulator;
        private int position;
        private State state;

        public Accumulator()
        {
            instructions = new List<Instruction>();
            accumulator = 0;
            position = 0;
            state = State.None;
        }

        public static Accumulator Setup(IEnumerable<string> Instructions)
        {
            Accumulator acc = new Accumulator();

            foreach (var instruction in Instructions)
            {
                string[] ops = instruction.Split(' ', 2);
                int off = int.Parse(ops[1]);
                Opcode code;
                switch (ops[0])
                {
                    case "nop":
                        code = Opcode.Nop;
                        break;
                    case "acc":
                        code = Opcode.Acc;
                        break;
                    case "jmp":
                        code = Opcode.Jmp;
                        break;
                    default:
                        code = Opcode.Nop;
                        break;
                }
                acc.AddInstruction(code, off);
            }


            return acc;
        }

        private void AddInstruction(Opcode code, int off)
        {
            instructions.Add(new Instruction(code, off));
        }

        public int Run()
        {
            accumulator = 0;
            position = 0;
            state = State.Ready;
            foreach (var ins in instructions)
            {
                ins.Visited = false;
            }

            while (true)
            {
                Console.WriteLine(String.Format("{0} {1}", position, instructions[position].ToString()));
                int off = 1;

                if (instructions[position].Opcode == Opcode.Acc)
                {
                    accumulator += instructions[position].Offset;
                }
                else if (instructions[position].Opcode == Opcode.Jmp)
                {
                    off = instructions[position].Offset;
                }

                instructions[position].Visited = true;

                position += off;

                if (position == instructions.Count)
                {
                    state = State.Terminated;
                    break;
                }
                else if (position > instructions.Count || position < 0)
                {
                    state = State.OutOfBounds;
                    break;
                }

                if (instructions[position].Visited)
                {
                    state = State.EndlessLoop;
                    break;
                }
            }

            return accumulator;
        }

        public State State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public List<Instruction> GetInstructions => instructions;

        public void FlipInstruction(int index)
        {
            instructions[index].Opcode = (instructions[index].Opcode == Opcode.Jmp) ? Opcode.Nop : Opcode.Jmp ;
        }
    }

    public enum Opcode
    {
        Nop,
        Acc,
        Jmp
    }

    public enum State
    {
        None,
        Ready,
        EndlessLoop,
        Terminated,
        OutOfBounds
    }

    public class Instruction
    {
        private Opcode opcode;
        private int offset;
        private bool visited;

        public Instruction(Opcode code, int off)
        {
            opcode = code;
            offset = off;
            visited = false;
        }

        public bool Visited
        {
            get
            {
                return visited;
            }
            set
            {
                visited = value;
            }
        }

        public int Offset
        {
            get
            {
                return offset;
            }
        }

        public Opcode Opcode
        {
            get
            {
                return opcode;
            }
            set
            {
                opcode = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", opcode, offset, visited);
        }
    }
}
