using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AGLTest
{
    public class ErrorResponse
    {
        public Collection<string> Errors { get { return _errors; } }
        private Collection<string> _errors = new Collection<string>();
        public void AddErrors(string errorMessage)
        {
            _errors.Add(errorMessage);
        }
    }
}