using WaterFlowApiRest.Models;

namespace WaterFlowApiRest.Repositories
{
    public class WaterFlowsRepository
    {
        private readonly List<WaterFlow> Data;
        private int _nextId = 1;
        public WaterFlowsRepository()
        {
            Data = new List<WaterFlow>()
            {
                new WaterFlow{Id = _nextId++, Name = "AddItWater", Volume = 2, DateTime = DateTime.Now},
                new WaterFlow{Id = _nextId++, Name = "WaterMakers", Volume = 9, DateTime = DateTime.Now},
                new WaterFlow{Id = _nextId++, Name = "WaterStar", Volume = 4, DateTime = DateTime.Now},
                new WaterFlow{Id = _nextId++, Name = "LetItFlow", Volume = 3, DateTime = DateTime.Now }

            };
        }
        public List<WaterFlow> GetAll()
        {
            List<WaterFlow> WaterFlows = Data;
            return WaterFlows;
        }
        public WaterFlow? GetById(int id)
        {
            return Data.Find(WaterFlow => WaterFlow.Id == id);
        }
        public WaterFlow Add(WaterFlow WaterFlow)
        {
            WaterFlow.DateTime = DateTime.Now;
            WaterFlow.Id = _nextId++;
            Data.Add(WaterFlow);
            return WaterFlow;
        }
    }
}
