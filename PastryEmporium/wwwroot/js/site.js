﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function myFunction() {
    alert("Welcome to the Pastry Emporium Assistance Guide"
        + "\n\n\nA description of our shop can be found on the Home page, beneath 'About Pastry Emporium'."
        + "This details our purpose, standards and a bit about ourselves generally.\n\nBelow our description is"
        + "where you will find our available pastries.It is here that all available pastries are displayed with a name," 
        + "brief description, image and a price.To see all details related to a specific pastry, simply click anywhere" 
        + "in the pastry's display box and you will be redirected.\n\nAlso on the Home page is a short paragraph of our services."
        + "\n\nUnregistered users will solely be permitted to submit feedback, which can be done by selecting the 'Contact Us'"
        + "tab within the navigation bar.When selected, the user will be shown a message form where they must insert their"
        + "name, email address and message.Once sent, messages cannot be edited, deleted or viewed.\n\nUnregistered users also have the"
        + "option of logging into the application.By clicking the 'Login' tab within the navigation bar, the user will be required to enter a" 
        + "username and password.Invalid input will result in an error message.\n\nOnce logged in, registered users have access to the same"
        + "information as unregistered users.However, they are additionally permitted to access the pastries database where the details of all"
        + "available pastries, as well as the ability to create, edit or delete items.This database may be accessed by selecting the 'Pastries' tab"
        + "within the navigation bar.\n\nRegistered users have access to the customers database, where the details(name, address, town and county)"
        + "of customers is stored.Registered users may edit, delete and create new users to / from the database.The database may be accessed by"
        + "selecting the 'Customer' tab within the navigation bar.\n\nCustomer purchases may be seen, editted, deleted and created by registered"
        + "users by selecting the 'Purchases' tab within the navigation bar.It is here that the database details are stored, displaying the customer's"
        + "ID(created by database on new submittion) and a pastry ID.\n\nAdditionally to creating feedback, registered users also have access to"
        + "viewing, deleting and editing feedback.\n\nOnly an admin may register a new user to the application, which may be done by selecting the"
        + "'Register' tab within the navigation bar.\n\nTo access out privacy policy, click 'Privacy' within the footer tab.\n\nOnce 'OK' is clicked"
        + "the current page will be refreshed.\n\n\nIf you have any inquiries, feel free to leave us a message and we will get back to you as soon"
        + "as we can.Thank you!\n\n© 2019 - Pastry Emporium");
}

$(document).ready(function (e) {
    var width = $(document).width();

    function goRight() {
        $(".home-img").animate({
            left: 240
        }, 6000, function () {
            setTimeout(goLeft, 50);
        });
    }
    function goLeft() {
        $(".home-img").animate({
            left: 0
        }, 6000, function () {
            setTimeout(goRight, 50);
        });
    }

    setTimeout(goRight, 50);
});