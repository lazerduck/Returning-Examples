using System;

namespace Returning_Examples
{
    public class DummyRepository
    {
        public DummyModel GetReturnDefault(string id)
        {
            return new DummyModel();
        }

        public DummyModel? GetReturnNull(string id)
        {
            return null;
        }

        public bool TryGetDummy(string id, out DummyModel? model)
        {
            model = null;
            return false;
        }
    }
}