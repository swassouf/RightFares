using Organization.Application.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.DTO.Implementation
{
    public class Result<T>: IMethodValidationResult
    {
        /// <summary>
        /// Value generated from method
        /// </summary>
        public T Value { get; set; }
    }
}
