// Decompiled with JetBrains decompiler
// Type: Lesson_7.Program
// Assembly: Lesson_7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AD345A92-D4A9-4809-9F0A-90AA64D219C3
// Assembly location: C:\Users\sin27\source\repos\Lesson_7\bin\Release\net5.0\Lesson_7.dll

using System;

namespace Lesson_7
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("What's your name?");
      string str = Console.ReadLine();
      Console.WriteLine("Hello " + str + "!");
      int num = str == "sasha" ? 1 : 0;
      Console.ReadKey(true);
    }
  }
}
