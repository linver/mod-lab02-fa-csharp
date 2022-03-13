using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


// Разработать класс ДКА, который допускает бинарную строку, 
// содержащую ровно один '0' и хотя бы одну '1'. 
  public class FA1 
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State b = new State()
    {
        Name = "b",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
        Name = "c",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;
    
    public FA()
    {
        a.Transitions['0'] = b;
        a.Transitions['1'] = a;
        b.Transitions['0'] = c;
        b.Transitions['1'] = b;
        c.Transitions['0'] = c;
        c.Transitions['1'] = c;            
    }
    
    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
            if (current == null)              // если его нет, возвращаем признак ошибки
                return null;
            // иначе переходим к следующему
        }
        return current.IsAcceptState;         // результат true если в конце финальное состояние 
    }
  }


  // Разработать класс ДКА, который допускает бинарную строку, 
  // содержащую нечетное количество символов '0' и нечетное количество символов '1'.
  public class FA2
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State b = new State()
    {
        Name = "b",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
        Name = "c",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };
    public State d = new State()
    {
        Name = "d",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;
    
    public FA()
    {
        a.Transitions['0'] = d;
        a.Transitions['1'] = b;
        b.Transitions['0'] = c;
        b.Transitions['1'] = a;
        c.Transitions['0'] = b;
        c.Transitions['1'] = d; 
        d.Transitions['0'] = a;
        d.Transitions['1'] = c;           
    }
    
    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s)
        {
            current = current.Transitions[c];
            if (current == null)
                return null;
        }
        return current.IsAcceptState;
    } 
  }
  
  // Разработать класс ДКА, который допускает бинарную строку, содержащую  '11'.
  public class FA3
  {
    public static State a = new State()
    {
        Name = "a",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State b = new State()
    {
        Name = "b",
        IsAcceptState = false,
        Transitions = new Dictionary<char, State>()
    };
    public State c = new State()
    {
        Name = "c",
        IsAcceptState = true,
        Transitions = new Dictionary<char, State>()
    };

    State InitialState = a;
    
    public FA()
    {
        a.Transitions['0'] = a;
        a.Transitions['1'] = b;
        b.Transitions['0'] = а;
        b.Transitions['1'] = b;
        c.Transitions['0'] = c;
        c.Transitions['1'] = c;            
    }
    
    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
        foreach (var c in s) // цикл по всем символам 
        {
            current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
            if (current == null)              // если его нет, возвращаем признак ошибки
                return null;
            // иначе переходим к следующему
        }
        return current.IsAcceptState;         // результат true если в конце финальное состояние 
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}