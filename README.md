# Code Style Conventions
1. Naming rules
2. Formating
3. Namespaces

## 1 Naming Rules

* Type names start with a capital letter and have a capital letter for each new word, with no underscores (UpperCamelCase)
* The names of variables (including function parameters) and public data members are all camelCase (lowerCamelCase)
* The names of methods are all PascalCase (UpperCamelCase)
* The names of private data members are all camelCase with leading underscore
* The names of constants and static data members are all PascalCase

## 2 Formating

* 1 Tab = 4 spaces
* Each line of text in your code should be at most 80 characters long
* The if and else keywords belong on separate lines. There should be a space between the if and the open parenthesis, and between the close parenthesis and the curly brace (if any), but no space between the parentheses and the condition.
* There should be a space between the operator and the operands
* Class data members should be in the bottom of the class defenition like this:
```C#
class Sample
{
    void FuncSample()
    {
        if (a == b)
        {

        }
        else 
        {

        }
    }

    //data members
    public int firstMember;
    
    private int _secondMember;
}
```
## 3 Every class has to belong to a namespace
scripts/HealthFightSystem/HealthSystem/Load.cs
```C#
namespace HealthFight
{
    namespace HealthSystem
    {
        public class Load
        {
            
        }
    }
}
```
