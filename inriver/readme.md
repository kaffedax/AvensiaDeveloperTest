# Avensia inRiver PIM challange

The goal with this challenge is to determine your skill level and strengths as an **inRiver PIM developer**. The repository contains all the information you need to fulfill your assignment. Take your time and read through the whole document before you proceed. If you have any questions don't hesitate to reach out to us.

## Table of contents

* [Gettings started](#getting-started)
* [Assignment](#assignment)
* [Submitting](#submitting)

## Getting started

1.  Login to [Github](https://github.com/)
2.  Fork this repository (click the Fork button on the upper right-hand side of the page)
3.  Open your terminal and clone the fork to your computer *
    ```bash
    $ git clone https://github.com/<your_username>/avensia.developer-challenge
    ```
4. Go to https://demoinrivereuw.productmarketingcloud.com/ and login with demoa1@inriver.com / !Demoa1!

## Assignment

Your assignment is to review the iPMC Extension that listens to changes on Product and Resource.

There are two helper classes in the project. 

### ProductHelper

This will check a field on Product and set a corresponding FieldSet based on a mapping

### RespourceHelper

This will set the ResourceMedia field based on the MIME Type and also try link the Resource to a Product. 

### Questions

* How can the ProductHelper class be improved?
* How could extracting the Product Number from the filename be made more efficent and dynamically?
* What improvements could be done on the finding and linking between Product and Resource?
* Which performance improvements can be done on the DeveloperListener?

## Submitting

You don't have to actually code anything, but if you have time, feel free to perform your improvements. 
Push your commits and send us the link to your fork at Github (_No need for a pull request to our repository_). Then we'll book a time for a review with your contact at Avensia and one of our backend developers.

If you have any question, don't hesitate to contact us.

Good luck!
