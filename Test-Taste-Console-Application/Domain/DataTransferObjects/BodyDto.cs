using System.Collections.Generic;

namespace Test_Taste_Console_Application.Domain.DataTransferObjects
{
    public class BodyDto
    {
        public string id { get; set; }
        public string englishName { get; set; }
        public bool isPlanet { get; set; }
        public List<MoonDto> moons { get; set; } // Only ID and name
        public float? avgTemp { get; set; } // average temperature
    }

    public class BodiesResponse
    {
        public List<BodyDto> bodies { get; set; }
    }
}
