using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam2015.Qualification.A
{
    public class Output
    {
        private bool _debug;
        private string _fileName;
        private StreamWriter _outputFile;

        public Output() : this("Output.txt", false) { }

        public Output(string fileName, bool debug)
        {
            this._debug = debug;
            this._fileName = fileName;
            this._outputFile = new StreamWriter(_fileName);
        }

        public void Write(string value)
        {
            if (_debug)
            {
                Console.Write(value);
            }

            this._outputFile.Write(value);
        }

        public void Write(int value)
        {
            if (_debug)
            {
                Console.Write(value);
            }

            this._outputFile.Write(value);
        }

        public void WriteLine(string format, params object[] args)
        {
            if (_debug)
                Console.WriteLine(format, args);

            this._outputFile.WriteLine(format, args);
        }

        public void Flush()
        {
            this._outputFile.Flush();
        }

        public void Dispose()
        {
            this._outputFile.Dispose();
        }
    }
}
