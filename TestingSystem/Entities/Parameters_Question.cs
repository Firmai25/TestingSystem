//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingSystem.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parameters_Question
    {
        public int Id { get; set; }
        public Nullable<int> Id_question { get; set; }
    
        public virtual Question Question { get; set; }
    }
}