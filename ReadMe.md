# XSSPress blog app
XSSPress is a simple blogging web application. With it posts can be created directly in the browser from the restricted administration area.

## Requirements

### Hosting
- Microsoft® .NET Framework 4.8 on supported Windows versions.
- Microsoft® SQL Server 2016, 2017, 2019, and 2022

### Supported browsers
- Chrome

## SetUp
You must open a web browser to set up your project after it is hosted on IIS. You will be prompted to create the administrator user when you first run the app. The administrator user is the only user that can create blog posts and is tasked with developing the public site views and content.

## Administration views
To enter the administrative views of the app navigate to "_/admin_" path in the browser. You will be asked to login with the administrator account that was created initially.

### Blog posts list
The blog post list view is the default administrative view. It lists all the blog posts that have been created with the date of creation.

### Create blog post
You can create a new blog post by clicking on the "_Create Post_" link from Blog posts list view. Add a title and the post content then click "_Create_".

## Public views
These are intended to be viewed by the public website visitors.

### Blog posts list
This is the default view of the app that lists all the blogs that have been created by title. To view the blog post details simply click on its name.

### Blog post details
Displays the blog post details. To navigate back to the blog posts list click on the browser back button.