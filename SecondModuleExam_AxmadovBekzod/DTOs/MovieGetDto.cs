using SecondModuleExam_AxmadovBekzod.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondModuleExam_AxmadovBekzod.DTOs
{
    public class MovieGetDto: BaseMovieDto
    {
        public Guid Id { get; set; }
    }
}
