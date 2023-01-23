using System.Collections.Generic;
using System.Threading.Tasks;
using MonkeyMadness.Data;

namespace MonkeyMadness.Services;

public interface IMonkeyService
{
    Task<List<Monkey>> GetMonkeysAsync();
}
