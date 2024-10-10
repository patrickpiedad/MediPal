<h1 align="center"> MediPal </h1>
MediPal is open source medical software that gives users true access to their holistic health picture. This application is meant to simplify getting the important information to the person in ways they are able to understand.

<br></br>

<h2 align="center">Patient View</h2>
<p align="center">
  <img src= https://github.com/patrickpiedad/MediPal/blob/main/PatientView.gif alt="animated" />
</p>

<h2 align="center">Doctor View</h2>
<p align="center">
  <img src= https://github.com/patrickpiedad/MediPal/blob/main/DoctorView.gif alt="animated" />
</p>

<br></br>

<h1 align="center"> How It's Made </h1>
Tech Used: C#, Blazor Web App (.NET), Bootstrap, SQL Express
<br></br>
The project is based on Blazor Web App with capability of both client and server side rendering. All main information is currently stored server side, allowing for direct database access without required web API calls. Information is currently stored on local databases using SQL Express. 
<br></br>
Authentication and authorization are both applied to ensure proper access to the application, both through use of general user login and assigned roles. CRUD operations are executed to update information such as symptom tracking for each user.

<br></br>

<h1 align="center"> Inspiration </h1>
This project is inspired by the experience of my wife and I working through her cancer diagnosis and always having communication issues / information disconnects with the medical team. We were at the regional University Hospital that had the best team, but due to an overburdened medical system and the natural friction that occurs on teams, we encountered a lot of friction in knowing what was going on. 
<br></br>
I want this project to empower patients to learn more about their circumstances, relieve their pain points in communication, as well as provide a relief to the medical team's burden to keep patient's constantly performed in an already overwhelming environment.

<br></br>

<h1 align="center"> Featured Implementations </h1>
<h3>Major Features</h3>
<ul>
    <li>Model-View-ViewModel (MVVM) Architecture</li>
    <ul>
        <li>Model (database, models such as Symptom and ApplicationUser)</li>
        <li>ViewModel (Code blocks in razor files, commands, and services interfaces)</li>
        <li>View (razor components and HTML templates</li>
    </ul>
    <li>Account creation with full form validation and error handling</li>
    <li>Full CRUD functionality MS SQL Server database</li>
    <ul>
        <li>Symptoms</li>
        <li>Notes</li>
    </ul>
    <li>ASP.NET Core Identity implementation with authentication and authorization</li>
    <li>Current user authentication state handling to display user-specific data</li>
    <li>Create calendar appointment functionality (Syncfusion), display in multiple formats</li>
    <li>Doctor Dashboard allowing for selection of patient by name (read by patientId) and view/edit of information</li>
</ul>

<h3>Smaller Details</h3>
<ul>
    <li>Models containing properties with backing fields and constructor</li>
    <li>List collection to hold symptoms (accessed through interface)</li>
    <li>List collection to hold doctors (hard coded)</li>
    <li>Button interactivity to validate properties with model and allow/not allow for form submit as appropriate</li>
    <li>Logic to execute specific actions if collections do not show, async functionality, JavaScript interaction when deleting symptoms for user-feedback.</li>
    <li>Model classes for base object structure</li>
    <li>Service interfaces to allow for abstracted interaction with async functions and loosely coupled components</li>
    <li>Foreign key implementation in relational database (MS SQL Server)</li>
    <li>Authorization role based access for specific pages and components</li>
    <li>Populate user dashboard items with user account information using current user authentication</li>
    <li>Database seeding to ensure admin account, roles, and other features are always added to database in new environments</li>
</ul>

<br></br>

<h1 align="center"> Optimizations </h1>
<ul>
  <li>Client-Side rendering for specific features</li>
  <li>Chat Functionality</li>
  <li>Cloud Storage</li>
  <li>Add Azure Open Search integration</li>
  <li>Add Open AI integration</li
</ul>

<br></br>

<h1 align="center"> Lessons Learned </h1>
This project has taught me how to implement C# fundamentals into an actual .NET application framework. I've learned about application design, dependency injection, authorization and authentication, database integration with personal and foreign keys, and many other topics.

<br></br>

More importantly, I've learned that there are technical aspects, such as the code design and implementation, and there are functional aspects, referring to how the program functions when used by an actual user. The key to building a great project is bridging these two concepts. 
<br></br>
