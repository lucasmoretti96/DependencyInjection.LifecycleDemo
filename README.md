# DependencyInjection.LifecycleDemo
	A simple program to study the lifecycle of dependency injection services in .NET

# DependencyInjection

## Benefits
	- Code reuse and maintenance
	- Testable and extensive code
	- Simple coding and can be applied in any situation where are different behaviors
	
## Disadvantages
	- Unecessary and excessive use can affect performance

## Application lifecycle types
	- Singleton: One shared instance for the lifetime of the application
		- Generally more perfomant
		- Allocates less objects
		- Reduces load on GC (Garbage Collector)
		- Most be thread-safe
		- Suited to functional stateless services(Example: Memory Cache)
		- Consider frequency of use vs. memory
		
	- Transient: Creates a new instance of the object every time
		- Not required to be thread-safe 
		- Potentially less efficient
		- Easiest to reason about

	- Scoped: An instance per scope(request)
		- 
