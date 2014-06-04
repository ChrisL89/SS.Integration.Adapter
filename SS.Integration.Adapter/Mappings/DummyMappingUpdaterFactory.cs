﻿//Copyright 2014 Spin Services Limited

//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at

//    http://www.apache.org/licenses/LICENSE-2.0

//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.


using SS.Integration.Adapter.Plugin.Model.Interface;
using SS.Integration.Adapter.Plugin.Model;

namespace SS.Integration.Adapter.Mappings
{
    public class DummyMappingUpdaterFactory : IMappingUpdaterFactory
    {
        private static IMappingUpdater _mappingUpdater;
        private static readonly object _syncLock = new object();

        public MappingUpdaterConfiguration Configuration { get; set; }
        
        IMappingUpdater IMappingUpdaterFactory.GetMappingUpdater()
        {
            return GetMappingUpdater();
        }

        public static IMappingUpdater GetMappingUpdater()
        {
            if (_mappingUpdater != null)
                return _mappingUpdater;

            lock (_syncLock)
            {
                if (_mappingUpdater != null)
                    return _mappingUpdater;

                _mappingUpdater = new DummyMappingUpdater();
                return _mappingUpdater;
            }
        }
    }
}
