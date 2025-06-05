public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public FeatureProperties properties { get; set; }
}

public class FeatureProperties
{ 
    public Decimal? mag {get; set;}
    public string place {get; set;}
}