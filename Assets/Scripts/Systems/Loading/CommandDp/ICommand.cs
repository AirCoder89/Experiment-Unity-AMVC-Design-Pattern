using System;
using System.Collections.Generic;
using UnityEngine;

namespace AMVC.Systems.Loading.CommandDp
{
   public interface ICommand
   {
      bool IsDone { get;}
      void Execute();
      void Dispose();
   }
}