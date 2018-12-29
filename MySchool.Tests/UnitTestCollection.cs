using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MySchool.Tests
{
    [CollectionDefinition("Live tests")]
    public class UnitTestCollection : ICollectionFixture<MySchoolTestBase>
    {
        // Intentionally left blank.
        // This class only serves as an anchor for CollectionDefinition.
    }
}
