using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransformationObjects
{
    public class SongDto
    {
        public string Name
        { get; set; }

        public string Path
        { get; set; }

        public string FileType
        { get; set; }

        public string DateUsed
        { get; set; }

        public static explicit operator SongDto(List<DataRow> v)
        {
            throw new NotImplementedException();
        }
    }
}
