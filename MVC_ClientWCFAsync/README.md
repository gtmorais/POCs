# POCs
This is a simple poc that uses MVC Actions to make async calls to WCF services.

In the first action we have an async controller action that returns a Task<ActionResult>. 

In the second action we have a regular controller action that returns an ActionResult and the usage of a delegate parameter in the Task.Run method to make the async call without adding async task statements to the action signature.
