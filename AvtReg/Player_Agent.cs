//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvtReg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player_Agent
    {
        public int Id_player_agent { get; set; }
        public int Id_player { get; set; }
        public int Id_agent { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Player Player { get; set; }
    }
}
