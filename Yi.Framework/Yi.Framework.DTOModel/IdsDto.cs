using System;
using System.Collections.Generic;

namespace Yi.Framework.DTOModel
{
    public class IdDto<T>
    {
        public T id1 { get; set; }
        public T id2 { get; set; }
    }

    public class IdsDto<T>
    {
        public T id{ get; set; }
        public List<T> ids { get; set; }
    }

    public class IdsListDto<T>
    {
        public List<T> ids1 { get; set; }
        public List<T> ids2 { get; set; }
    }
}
