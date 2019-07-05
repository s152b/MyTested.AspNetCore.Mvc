<h1><img src="https://raw.githubusercontent.com/ivaylokenov/MyTested.AspNetCore.Mvc/master/tools/logo.png" align="left" alt="MyTested.AspNetCore.Mvc" width="100">&nbsp; MyTested.AspNetCore.Mvc - Fluent testing<br />&nbsp; library for ASP.NET Core MVC</h1> 

## Project Description

**MyTested.AspNetCore.Mvc** is a strongly-typed unit testing library providing an easy fluent interface to test the [ASP.NET Core MVC](https://github.com/aspnet/AspNetCore) framework. It is testing framework agnostic so that you can combine it with a test runner of your choice (e.g. [xUnit](https://github.com/xunit/xunit), [NUnit](https://github.com/nunit/nunit), etc.). 

*Windows:* [![Build status](https://ci.appveyor.com/api/projects/status/3xlag3a7f87bg4on?svg=true)](https://ci.appveyor.com/project/ivaylokenov/mytested-aspnetcore-mvc)

*Ubuntu & Mac OS:* [![Build Status](https://travis-ci.org/ivaylokenov/MyTested.AspNetCore.Mvc.svg?branch=development)](https://travis-ci.org/ivaylokenov/MyTested.AspNetCore.Mvc) 

*Downloads:* [![NuGet Badge](https://buildstats.info/nuget/MyTested.AspNetCore.Mvc)](https://www.nuget.org/packages/MyTested.AspNetCore.Mvc/)

**MyTested.AspNetCore.Mvc** has [more than 500 assertion methods](https://mytestedasp.net/Core/Mvc/Features) and is 100% covered by [more than 2000 unit tests](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/tree/version-2.1/test). It should work correctly. Almost all items in the [issues page](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/issues) are expected future features and enhancements.

**MyTested.AspNetCore.Mvc** will help you speed up the testing process in your web development team! If you find that statement unbelievable, these are the words which some of the many happy **MyTested.AspNetCore.Mvc** users once said: 
> "I’ve been using your packages for almost 3 years now and it has saved me countless hours in creating unit tests and wanted to thank you for making this. I cannot imagine how much code I would have had to write to create the 450+ and counting unit tests I have for my controllers."

> "I absolutely love this library and it greatly improved the unit/integration test experience in my team."

> ["Amazing library, makes you want to do test-driven development, thanks!"](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/issues/265#issue-194578165)

> "Wanted to thank you for your effort and time required to create this. This is a great tool! Keep up the good work."

Take a look around and...

⭐️ ...if you like the library, **star** the repository and show it to your friends!

👀 ...if you find it useful, make sure you **subscribe** for future releases by clicking the **"Watch"** button and choosing **"Releases only"**!

✔ ...if you want to support the project, take a look at [https://MyTestedASP.NET](https://mytestedasp.net) and consider purchasing a premium [license](#license)!

#### Featured in

- [The official ASP.NET Core MVC repository](https://github.com/aspnet/AspNetCore/tree/master/src/Mvc#aspnet-core-mvc)
- [NuGet Package of the week in "The week in .NET – 6/28/2016"](https://devblogs.microsoft.com/dotnet/the-week-in-net-6282016/)
- [Awesome .NET Core](https://github.com/thangchung/awesome-dotnet-core#testing)

## Quick Start

To add **MyTested.AspNetCore.Mvc** to your solution, you must follow these simple steps:

1. Create a test project.
2. Reference your web application.
3. Install **`MyTested.AspNetCore.Mvc.Universe`** (or just the [testing packages](#package-installation) you need) from [NuGet](https://www.nuget.org/packages/MyTested.AspNetCore.Mvc.Universe/).
4. Open the test project's `.csproj` file.
5. Change the project SDK to `Microsoft.NET.Sdk.Web`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
```

6. Add a package reference to the web framework - `Microsoft.AspNetCore.App`:

```xml
<PackageReference Include="Microsoft.AspNetCore.App" />
```

7. Your test project's `.csproj` file should be similar to this one:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web"> <!-- Changed project SDK -->

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" /> <!-- Reference to the web framework -->
    <PackageReference Include="MyTested.AspNetCore.Mvc.Universe" Version="2.1.0" /> <!-- My Tested ASP.NET Core MVC -->
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.9.0" />
    <PackageReference Include="xunit" Version="2.4.0" /> <!-- Can be any testing framework --> 
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyApp\MyApp.csproj" /> <!-- Reference to your web project --> 
  </ItemGroup>

</Project>
```

8. Create a `TestStartup` class at the root of the test project in order to register the dependency injection services which will be used by all test cases in the assembly. A quick solution is to inherit from the web project's `Startup` class. By default **MyTested.AspNetCore.Mvc** replaces all ASP.NET Core services with ready to be used mocks. You only need to replace your own custom services with mocked ones by using the provided extension methods. 

```c#
namespace MyApp.Tests
{
    using MyTested.AspNetCore.Mvc;
	
    using Microsoft.Extensions.DependencyInjection;

    public class TestStartup : Startup
    {
        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
			
            // Replace only your own custom services. The ASP.NET Core ones 
            // are already replaced by MyTested.AspNetCore.Mvc. 
            services.Replace<IService, MockedService>();
        }
    }
}
```

9. Create a test case by using the fluent API the library provides. You are given a static `MyMvc` class from which all assertions can be easily configured:

```c#
namespace MyApp.Tests.Controllers
{
    using MyTested.AspNetCore.Mvc;
	
    using MyApp.Controllers;
    using Xunit;

    public class HomeControllerShould
    {
        [Fact]
        public void ReturnViewWhenCallingIndexAction()
        {
            MyMvc
                .Controller<HomeController>()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();
        }
    }
}
```

Basically, **MyTested.AspNetCore.Mvc** throws an unhandled exception with a friendly error message if the assertion does not pass and the test fails. The example uses [xUnit](http://xunit.github.io/), but you can use any other framework you like. See the [samples](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/tree/version-2.1/samples) for other types of test runners and `Startup` class configurations.

## Detailed Documentation

It is strongly advised to read the [tutorial](http://docs.mytestedasp.net/tutorial/intro.html) in order to get familiar with **MyTested.AspNetCore.Mvc** in more details. Additionally, you may see the [testing guide](http://docs.mytestedasp.net/guide/intro.html) or the [API reference](http://docs.mytestedasp.net/api/index.html) for a full list of available features.

You can also check out the [provided samples](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/tree/version-2.1/samples) for real-life ASP.NET Core MVC application testing.

## Package Installation

You can install this library using [NuGet](https://www.nuget.org/packages/MyTested.AspNetCore.Mvc.Universe) into your test project (or reference it directly in your `.csproj` file). Currently **MyTested.AspNetCore.Mvc** is fully compatible with ASP.NET Core MVC 2.1.0 and all older versions available on the official NuGet feed.

```powershell
Install-Package MyTested.AspNetCore.Mvc.Universe
```

This package will include all available assertion methods in your test project, including ones for authentication, database, session, caching and more. If you want only the MVC related features, install `MyTested.AspNetCore.Mvc`. If you want to use the completely **FREE** and **UNLIMITED** version of the library, install only `MyTested.AspNetCore.Mvc.Lite` and no other package. Additionally, if you prefer, you can be more specific by including only some of the packages:

 - `MyTested.AspNetCore.Mvc.Configuration` - Contains setup and assertion methods for configurations
 - `MyTested.AspNetCore.Mvc.Controllers` - Contains setup and assertion methods for controllers
 - `MyTested.AspNetCore.Mvc.Controllers.Attributes` - Contains setup and assertion methods for controller attributes
 - `MyTested.AspNetCore.Mvc.Controllers.ActionResults` - Contains setup and assertion methods for controller API action results
 - `MyTested.AspNetCore.Mvc.Controllers.Views` - Contains setup and assertion methods for controller view features
 - `MyTested.AspNetCore.Mvc.Controllers.Views.ActionResults` - Contains setup and assertion methods for controller view action results
 - `MyTested.AspNetCore.Mvc.Models` - Contains setup and assertion methods for response and view models
 - `MyTested.AspNetCore.Mvc.Routing` - Contains setup and assertion methods for routes
 - `MyTested.AspNetCore.Mvc.Core` - Contains setup and assertion methods for MVC core features
 - `MyTested.AspNetCore.Mvc.TempData` - Contains setup and assertion methods for `ITempDataDictionary`
 - `MyTested.AspNetCore.Mvc.ViewData` - Contains assertion methods for `ViewDataDictionary` and dynamic `ViewBag`
 - `MyTested.AspNetCore.Mvc.ViewComponents` - Contains setup and assertion methods for view components
 - `MyTested.AspNetCore.Mvc.ViewComponents.Attributes` - Contains setup and assertion methods for view component attributes
 - `MyTested.AspNetCore.Mvc.ViewComponents.Results` - Contains setup and assertion methods for view component results
 - `MyTested.AspNetCore.Mvc.ViewFeatures` - Contains setup and assertion methods for MVC view features
 - `MyTested.AspNetCore.Mvc.Http` - Contains setup and assertion methods for HTTP context, request and response
 - `MyTested.AspNetCore.Mvc.Authentication` - Contains setup methods for `ClaimsPrincipal`
 - `MyTested.AspNetCore.Mvc.ModelState` - Contains setup and assertion methods for `ModelStateDictionary` validations
 - `MyTested.AspNetCore.Mvc.DataAnnotations` - Contains setup and assertion methods for data annotation validations
 - `MyTested.AspNetCore.Mvc.EntityFrameworkCore` - Contains setup and assertion methods for `DbContext`
 - `MyTested.AspNetCore.Mvc.DependencyInjection` - Contains setup methods for dependency injection services
 - `MyTested.AspNetCore.Mvc.Caching` - Contains setup and assertion methods for `IMemoryCache`
 - `MyTested.AspNetCore.Mvc.Session` - Contains setup and assertion methods for `ISession`
 - `MyTested.AspNetCore.Mvc.Options` - Contains setup and assertion methods for `IOptions`
 - `MyTested.AspNetCore.Mvc.Helpers` - Contains additional helper methods for easier assertions
 - `MyTested.AspNetCore.Mvc.Lite` - Completely **FREE** and **UNLIMITED** version of the library. It should not be used in combination with any other package. Includes `Controllers`, `ViewActionResults` and `ViewComponents`.
 
After the downloading is complete, just add `using MyTested.AspNetCore.Mvc;` to your source code and you are ready to test in the most elegant and developer friendly way.

```c#	
using MyTested.AspNetCore.Mvc;
```

## Test Examples

Here are some examples of how powerful the fluent testing API actually is! **MyTested.AspNetCore.Mvc** is so awesome that every test can be written in one single line like in this [application sample](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/tree/version-2.1/samples/Blog)!

### Controller Integration Test

Uses the globally registered services in the `TestStartup` class:

```c#
// Instantiates controller with the registered global services,
// and mocks authenticated user,
// and tests for valid model state,
// and tests for added by the action view bag entry,
// and tests for view result and model with specific assertions.
MyController<MvcController>
    .Instance()
    .WithUser(user => user
        .WithUsername("MyUserName"))
    .Calling(c => c.SomeAction(requestModel))
    .ShouldHave()
    .ValidModelState()
    .AndAlso()
    .ShouldHave()
    .ViewBag(viewBag => viewBag
        .ContainingEntry("MyViewBagProperty", "MyViewBagValue"))
    .AndAlso()
    .ShouldReturn()
    .View(result => result
        .WithModelOfType<ResponseModel>()
        .Passing(m =>
        {
            Assert.AreEqual(1, m.Id);
            Assert.AreEqual("Some property value", m.SomeProperty);
        }));

// Instantiates controller with the registered global services,
// and sets options for the current test,
// and sets session for the current test,
// and sets DbContext data for the current test,
// and tests for added by the action cache entry,
// and tests for view result with specific model type.
MyController<MvcController>
    .Instance()
    .WithOptions(options => options
        .For<AppSettings>(settings => settings.Cache = true))
    .WithSession(session => session
        .WithEntry("Session", "SessionValue"))
    .WithData(data => data
        .WithEntities(entities => entities
            .AddRange(SampleDataProvider.GetModels())))
    .Calling(c => c.SomeAction())
    .ShouldHave()
    .MemoryCache(cache => cache
        .ContainingEntry(entry => entry
            .WithKey("CacheEntry")
            .WithSlidingExpiration(TimeSpan.FromMinutes(10))
            .WithValueOfType<CachedModel>()
            .Passing(a => a.Id == 1)))
    .AndAlso()
    .ShouldReturn()
    .View(result => result
        .WithModelOfType<ResponseModel>());

// Instantiates controller with the registered global services,
// and tests for valid model state,
// and tests for saved data in the DbContext after the action call,
// and tests for added by the action temp data entry with а specific key,
// and tests for redirect result to specific action. 
MyController<MvcController>
    .Instance()
    .Calling(c => c.SomeAction(new FormModel
    {
        Title = title,
        Content = content
    }))
    .ShouldHave()
    .ValidModelState()
    .AndAlso()
    .ShouldHave()
    .Data(data => data
        .WithSet<SomeModel>(set => set 
            .Should() // Uses FluentAssertions.
            .NotBeEmpty()
            .And
            .ContainSingle(m => m.Title == title)))
    .AndAlso()
    .ShouldHave()
    .TempData(tempData => tempData
        .ContainingEntryWithKey(ControllerConstants.SuccessMessage))
    .AndAlso()
    .ShouldReturn()
    .Redirect(redirect => redirect
        .To<AnotherController>(c => c.AnotherAction()));
```

The last test uses [Fluent Assertions](https://github.com/fluentassertions/fluentassertions) to further enhance the testing API. Another good alternative is [Shouldly](https://github.com/shouldly/shouldly).

### Controller Unit Test

Uses service mocks explicitly provided in each test: 

```c#
// Instantiates controller with the provided service mocks,
// and tests for view result.
MyController<MvcController>
    .Instance()
    .WithDependencies(
        serviceMock,
        anotherServiceMock,
		From.Services<IYetAnotherService>()) // Provides a global service.
    .Calling(c => c.SomeAction())
    .ShouldReturn()
    .View();
	
// Instantiates controller with the provided service mocks,
// and tests for view result.
MyController<MvcController>
    .Instance()
    .WithDependencies(dependencies => dependencies
        .With<IService>(serviceMock)
        .WithNo<IAnotherService>()) // Provides null for IAnotherService.
    .Calling(c => c.SomeAction(From.Services<IYetAnotherService>())) // Provides a global service.
    .ShouldReturn()
    .View();
```

### Route Test

Validates the web application's routing configuration:

```c#
// Tests a route for correct controller, action, and resolved route values.
MyRouting
    .Configuration()
    .ShouldMap("/My/Action/1")
    .To<MyController>(c => c.Action(1));

// Tests a route for correct controller, action, and resolved route values
// with authenticated post request and submitted form.
MyRouting
    .Configuration()
    .ShouldMap(request => request
        .WithMethod(HttpMethod.Post)
        .WithLocation("/My/Action")
        .WithFormFields(new
        {
            Title = title,
            Content = content
        })
        .WithUser()
        .WithAntiForgeryToken())
    .To<MyController>(c => c.Action(new FormModel
    {
        Title = title,
        Content = content
    }))
    .AndAlso()
    .ToValidModelState();

// Tests a route for correct controller, action, and resolved route values
// with authenticated post request and JSON body.
MyRouting
    .Configuration()
    .ShouldMap(request => request
        .WithLocation("/My/Action/1")
        .WithMethod(HttpMethod.Post)
        .WithUser()
        .WithAntiForgeryToken()
        .WithJsonBody(new
        {
            Integer = 1,
            String = "Text"
        }))
    .To<MyController>(c => c.Action(1, new MyModel
    {
        Integer = 1,
        String = "Text"
    }))
    .AndAlso()
    .ToValidModelState();
```

### Attribute Declarations Test

Validates controller and action attribute declarations:

```c#
// Tests for specific controller attributes - Area and Authorize.
MyController<MvcController>
    .Instance()
    .ShouldHave()
    .Attributes(attributes => attributes
        .SpecifyingArea(ControllerConstants.AdministratorArea)
        .RestrictingForAuthorizedRequests(ControllerConstants.AdministratorRole));

// Tests for specific action attributes - HttpGet, AllowAnonymous, ValidateAntiForgeryToken, and ActionName.
MyController<MvcController>
    .Instance()
    .Calling(c => c.SomeAction(With.Empty<int>())) // Provides no value for the action parameter.
    .ShouldHave()
    .ActionAttributes(attributes => attributes
        .RestrictingForHttpMethod(HttpMethod.Get)
        .AllowingAnonymousRequests()
        .ValidatingAntiForgeryToken()
        .ChangingActionNameTo("AnotherAction"));
```

### View Component Test

All applicable methods are available on the view component testing API too:

```c#
// View component integration test.
MyViewComponent<MvcComponent>
    .Instance()
	.WithSession(session => session
		.WithEntry("Session", "SessionValue"))
	.WithData(data => data
        .WithEntities(entities => entities
		    .AddRange(SampleDataProvider.GetModels())))
	.InvokedWith(c => c.InvokeAsync(1))
	.ShouldHave()
	.ViewBag(viewBag => viewBag
		.ContainingEntry("TotalItems", 10)
		.ContainingEntry("EntryName", "ViewBagName"))
	.AndAlso()
	.ShouldReturn()
	.View()
	.WithModelOfType<ResponseModel>();
	
// View component unit test.
MyViewComponent<MvcComponent>
    .Instance()
    .WithDependencies(
        serviceMock,
        anotherServiceMock,
        From.Services<IYetAnotherService>()) // Provides a global service.
    .InvokedWith(c => c.InvokeAsync(1))
    .ShouldReturn()
    .View();
```

### Arrange, Act, Assert (AAA) Test

**MyTested.AspNetCore.Mvc** is fully compatible with the AAA testing methodology:

```c#
// Without breaking the fluent API.
MyMvc

    // Arrange
    .Controller<MvcController>()
    .WithHttpRequest(request => request
        .WithFormField("SomeField", "SomeValue"))
    .WithSession(session => session
        .WithEntry("Session", someId))
    .WithUser()
    .WithRouteData() // Populates the controller route data.
    .WithData(data => data
        .WithEntities(entities => 
            AddData(sessionId, entities)))
			
    // Act
    .Calling(c => c.Action(
        From.Services<DataContext>(), // Action injected services can be populated with this call.
        new Model { Id = id },
        CancellationToken.None))
			
    // Assert
    .ShouldReturn()
    .Redirect(redirect => redirect
	    .To<AnotherController>(c => c.AnotherAction(
            With.No<DataContext>(),
            id)));
			
// With variables.
```

```c#

// tests whether model state error exists by using lambda expression
// and with specific tests for the error messages
// and tests whether the action returns view with the same request model
MyMvc
	.Controller<MvcController>()
	.Calling(c => c.MyAction(requestWithErrors))
	.ShouldHave()
	.ModelState(modelState => modelState.For<RequestModel>()
		.ContainingNoErrorFor(m => m.NonRequiredProperty)
		.AndAlso()
		.ContainingErrorFor(m => m.RequiredProperty)
		.ThatEquals("The RequiredProperty field is required."))
	.AndAlso()
	.ShouldReturn()
	.View(requestWithErrors);

// tests whether the action throws
// an exception of particular type and with particular message
MyMvc
	.Controller<MvcController>()
	.Calling(c => c.ActionWithException())
	.ShouldThrow()
	.Exception()
	.OfType<NullReferenceException>()
	.AndAlso()
	.WithMessage()
	.ThatEquals("Test exception message");
```

## Versioning

My Tested ASP.NET Core MVC follows the ASP.NET Core MVC versions with which the testing framework is fully compatible. Specifically, the *major* and the *minor* versions will be incremented only when the MVC framework has a new official release. For example, version 1.0.0 of the testing framework will be fully compatible with ASP.NET Core MVC 1.0.0, version 1.1.0 will be fully compatible with ASP.NET Core MVC 1.1.0, version 1.3.15 will be fully compatible with ASP.NET Core MVC 1.3.0, and so on. 

The public interface of My Tested ASP.NET Core MVC will not have any breaking changes when the version increases (unless entirely necessary).

## License

Code by Ivaylo Kenov. Copyright 2015-2019 Ivaylo Kenov ([http://mytestedasp.net](http://mytestedasp.net))

MyTested.AspNetCore.Mvc.Lite (the **FREE** and **UNLIMITED** version of the testing library) is dual-licensed under either the Apache License, Version 2.0, or the Microsoft Public License (Ms-PL).

The source code of MyTested.AspNetCore.Mvc and its extensions (the full version of the testing library) is available under GNU Affero General Public License/FOSS License Exception. 

Without a license code, the full version of the library allows up to 100 assertions (around 25 test cases) per test project.

**Full-featured license codes can be requested for free by individuals, open-source projects, startups and educational institutions**. See [https://mytestedasp.net/Core/Mvc#free-usage](https://mytestedasp.net/Core/Mvc#free-usage) for more information.

Commercial licensing with premium support options is also available at [https://mytestedasp.net/Core/Mvc#pricing](https://mytestedasp.net/Core/Mvc#pricing).

See the [LICENSE](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/blob/master/LICENSE) for detailed information.

## Any questions, comments or additions?

If you have a feature request or bug report, leave an issue on the [issues page](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/issues) or send a [pull request](https://github.com/ivaylokenov/MyTested.AspNetCore.Mvc/pulls). For general questions and comments, use the [StackOverflow](http://stackoverflow.com/) forum.
