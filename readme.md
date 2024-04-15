## Dependency Injection

all dependencies are magically provided
 - no ned to use the new keyword
 - deep dependency trees are resolved

 how  does it work?
 - still put all dependencies as constructor arguments (constructor injection)
 - configure a container to satisfy dependencies in a particular way
 - use the container to initialize a component, including all of its dependencies

 DI advantages
 - reduction of boilerplate code
 - one central place where everything is configured
 - can externalized configuration
 - simple lifetime control
 - encapsulation

 DI disadvantages
 - creates an expection that configuration is done by construction code
 - behavior separated from construction makes code hard to read
 - requires an upfront development effort
 - can cause an explosion of types (esp. interfaces)

 ## IOC
 inversion of control inverts the control flow of a program
 simple example:
  - ordinary control: myList.Add(42)
  - inverted control: (42).AddTo(myList)

  dependency injection is a form of invertion of control where:
    - instead of using ordinary object composition...
    - ... you delegate that to the IOC container,
    - ... telling the container how you want the object to be built


    DI framework
    1. castle windsor
    2. structure map
    3. autofac
    4. unity
    5. ninject
    6. many other frameworks
    7.do it yourself

    why aotofac?
    1. actively developed/maintained
    2. very well documented
    3. support for a large number of technologies
    4. modular an extensible
    5. well-known authors


    terminology
    - Component
      a body of code that declares the services it provides and the dependencies it consumes
    - Service
      A contract between a providing and consuming component
    - dependency
      a service required by a component
    - container
      manages the components that make up the application

Two-step construction
 - use a containerBuilder to register components
 - use the contianer to resolve each required component

 types are registered with
 - builder.RegisterType<Foo>()
   Registers a component of type Foo
 - builder.RegisterType<Foo>().As<IFoo>()
   Regiastera component of type Foo to provide service IFoo

By default, last registration for the service is the one that's used
 - builder.RegisterType<Foo>().AS<IFoo>()
 - builder.RegisterType<Bar>().As<IFoo>()
 - container.Resolve<IFoo>();// yield an instance of Bar
Can prevent registration from changing default
- builder.RegisterType<Bar>()
  .As<IFoo>().PreserveExistingDefaults()

Constructor with most arguments is chosen by default

override constructor to be used with
- builder.RegisterType<Foo>().UsingConstrcutor(typeof(Bar), typeof(Baz))

Can register instances instead of types (useful for testing)



