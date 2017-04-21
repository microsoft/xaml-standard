using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlStandardDifferencer
{
    public class CSVWriter
    {
        private StreamWriter _writer;

        public CSVWriter(String filename)
        {
            _writer = new StreamWriter(filename);
        }

        public void AddRow(List<String> values)
        {
            AddRow(values.ToArray());
        }

        public void AddRow(params String[] values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                _writer.Write("\"{0}\"", values[i]);
                if (i < values.Length - 1)
                {
                    {
                        _writer.Write(",");
                    }
                }
            }
            _writer.WriteLine();
        }

        public void Close()
        {
            _writer.Close();
        }
    }
}
