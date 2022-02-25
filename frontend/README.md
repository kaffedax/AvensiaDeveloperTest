# Avensia frontend challenge

The goal with this challenge is to determine your skill level and strengths as a **frontend developer**. The repository contains all the information you need to fulfill your assignment. Take your time and read through the whole document before you proceed. If you have any questions don't hesitate to reach out to us.

## Table of contents

* [Gettings started](#getting-started)
* [Setup](#setup)
* [Assignment](#assignment)
* [Requirements](#requirements)
* [Submitting](#submitting)

## Getting started

1.  Login to [Github](https://github.com/)
1.  Fork this repository (click the Fork button on the upper right-hand side of the page)
1.  Open your terminal and clone the fork to your computer *
    ```bash
    $ git clone https://github.com/<your_username>/avensia.developer-challenge
    ```
    _* You need to have [Git](https://git-scm.com/downloads) installed on your computer_

## Setup

1. Install packages

    Navigate to the folder of your clone and run

    ```bash
    $ yarn install
    ```

1. Start servers

    ```bash
    $ yarn start
    ```
    
    This will start [Parcel](https://parceljs.org/) at http://localhost:1234 which runs your application and a mocked API server at http://localhost:8181.
    
## Assignment

Your assignment is to create a **shopping cart** - an important component in every e-commerce solution that allows visitors to select items for purchase. 

The [API Server](https://github.com/avensia/api-sample-server) is a backend with endpoint for getting products & managing your cart, which we expect you to use. Please read [the documentation](https://github.com/avensia/api-sample-server).

We expect you to use [React](https://reactjs.org/) in your solution. In addition, you're encouraged to use TypeScript and CSS-in-JS which are both a part of our frontend tech stack. 

We also encourage you to explain your thoughts on technical decisions you make, either through a text document or through git commit messages.

You're free to focus on whatever aspect you wish. A visually beautiful solution can be just as impressive as a technically beautiful solution – you decide which of your strengths you want to display.

## Requirements

These requirements are the basics of a shopping cart. If you have limited amount of time for this assignment, you can complete those that fit your time frame.

Required
* As a user I can **see the image & name of each item** in my shopping cart
* As a user I can **add an item** to my shopping cart
* As a user I can **remove an item** from my shopping cart
* As a user I can **see the total cost** of my shopping cart

Optional
* As a user I can **increment and decrement the quantity of an item** in my shopping cart

[See wireframe example](WIREFRAME.md). _You are not required to follow the wireframe. Its purpose is to clarify what it could be._

## Submitting

When you feel ready to submit your work: Push your commits and send us the link to your fork at Github (_No need for a pull request to our repository_). Then we'll book a time for a review with your contact at Avensia and one of our frontend developers.

If you have any question, don't hesitate to contact us.

Good luck!

