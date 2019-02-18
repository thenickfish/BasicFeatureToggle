# BasicFeatureToggle

A simple way to add flexible feature toggles to your .NET project (full framework or .NET core) without additional dependencies. You can easily use (or not use) your own configuration system and dependency injection. Classes are used to represent toggles (no magic strings) for easy refactoring at the end of the life of the toggle.

### Available Toggles:

- BooleanFeatureToggle: returns a boolean (true/ false) value based on your own logic
- DateRangeToggle: returns true during a specified date range span
- FileExistsFeatureToggle: returns true based on the existence of a file
- FlexibleFeatureToggle: generic toggle (accepts a T) that can return any type of object based on your logic

## Getting Started

Examples:

- [ASP.NET Core 2.1](src/Examples/ASP.NET%20Core%202.1)
- [ASP.NET Full Framework 4.7.2 (with Unity)](src/Examples/ASP.NET%204.7.2)

### Installing

Install the Nuget package

```
dotnet add package BasicFeatureToggle
```

Implement one of the abstract classes listed above to provide your value (this example is called "YourToggle" and returns a boolean)

```c#
public class YourToggle : BooleanFeatureToggle
{
    private readonly IConfiguration _configuration;
    public BoolFromConfigToggle(IConfiguration configuration) => _configuration = configuration;
    public override bool FeatureEnabled => bool.Parse(_configuration["YourToggleConfigKey"]);
    public override Task<bool> IsFeatureEnabledAsync(CancellationToken cancellationToken) => Task.FromResult(FeatureEnabled);
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

You can also use the flexible toggle to return anything you need, based on your own logic. Here's an example that returns the current second as an int:

```c#
public class GetDiscountPercentageToggle : FlexibleFeatureToggle<double>
{
    protected override double GetToggleValue() => DateTime.Now.Hour < 10 ? .5 : .9;
    protected override Task<double> GetToggleValueTask(CancellationToken cancellationToken) => Task.FromResult(GetToggleValue());
}
```

## Authors

- **Nick Fish** - _Initial work_ - [thenickfish](https://github.com/thenickfish)

See also the list of [contributors](https://github.com/thenickfish/BasicFeatureToggle/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
