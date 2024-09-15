# Please make sure you have .NET 8 sdk pre installed in your environment.

# Please change your db connection string in appsettings.json file to make sure you can run the code.

# please use below commands to create database from the models as we are using code first approach.

dotnet ef migrations add Modelupdate --project EmployeeManagement.Data --startup-project EmployeeManagement.API
dotnet ef database update --project EmployeeManagement.Data --startup-project EmployeeManagement.API
