# BasicFeatureToggle

A simple way to add flexible feature toggles to your .NET project (full framework or .NET core). Designed so you can easily use (or not use) your own configuration system and dependency injection.

### Available Toggles:
- Basic Toggles
    - BooleanFeatureToggle - provide a boolean value from your config
    - ObjectFeatureToggle - provide an object value from your config
    - FileExistsFeatureToggle - provide a path to a file, if that file exists it will enable the toggle
    - EnabledDuringDateRangeToggle - provide a start and (optional) end date, this toggle will enable during that time
- Sql Server Toggles
    - SqlServerFeatureToggle - will run a query based on your configuration to return a scalar value from sql server
    - SqlServerBooleanFeatureToggle - identical to the SqlServerFeatureToggle, but casts the result to a boolean

## Getting Started
Examples:
- [ASP.NET Core 2.1](src/Examples/ASP.NET%20Core%202.1)
- [ASP.NET Full Framework 4.7.2 (with Unity)](src/Examples/ASP.NET%204.7.2)

### Installing

Install the Nuget package
```
dotnet add package BasicFeatureToggle
```

Create a class for your toggle that provides the value from your configuration (this example is "YourToggle")
```c#
public class YourToggle : BooleanFeatureToggle
{
    public YourToggle(IConfiguration configuration) : base(configuration["YourToggleConfigKey"])
    {
    }
}
```

use an instance in your code to make decisions
```c#
public int GetResult(IConfiguration config)
{
    var yourToggle = new YourToggle(config);
    if (yourToggle.FeatureEnabled)
        return 1;
    else
        return 0;
}
```

## Authors

* **Nick Fish** - *Initial work* - [thenickfish](https://github.com/thenickfish)

See also the list of [contributors](https://github.com/thenickfish/BasicFeatureToggle/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details