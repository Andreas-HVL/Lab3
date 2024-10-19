# Report

This program is written with the expectation of being the followup to a login-function to a Gym's website, so only a single user will be relevant, and as such has been called "John Doe" in the program as a placeholder.
This User class has a few basic functions allowing it to book and unbook passes, these can easily be expanded by adding more properties or functions to accomodate future requirements.

//
The Pass class represents a gym session with basic information such as workout type, time, and available slots. 
If additional information needs to be tracked (e.g., instructor name, equipment required), the class can easily be extended by adding new properties and methods

//
The BookingManager currently serves as a placeholder that generates and manages the list of available passes.
In the future, it could serve as the interface between the program and a database or API, managing the retrieval and updating of data.
Currently, it instantiates dummy data, but this can easily be replaced by real-time data fetching in the future.

//
The RelayCommand and ObservableObject classes are key components of the MVVM pattern used in this program.
RelayCommand allows binding of UI Actions (Such a Button Clicks) to methods in the ViewModel enabling interaction between componnts without tightly coupling UI to Logic
ObservableObject simplifies notifications sent by updated properties via the INotifyPropertyChanged interface, ensurgin that changes made in the ViewModel are reflected in the Views.

//
As the Search Function is being used in 2 places (Booking/Unbooking) already, the base functionality was moved to a separate PassSearchHelper class.
Here additional functions can be added in the future if needed and can be called anywhere in the program.



