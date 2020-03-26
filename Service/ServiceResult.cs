using System.Collections.Generic;

namespace scm.Service
{
    public class ServiceResult<T>{
        public bool isSuccess{get; set;}
        public T Result { get; set; } ///este para cuando quieras mandar solo una cosa, por ejemplo, un usuario especifico
        public List<T> Results {get; set;} // este para cuando quieras mandar mas de una cosa, por ejemplo una lista de usuarios
        public List<string> Errors { get; set; }
    }
}