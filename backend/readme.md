# Avensia backend challenge

The goal with this challenge is to determine your skill level and strengths as a **backend developer**. The repository contains all the information you need to fulfill your assignment. Take your time and read through the whole document before you proceed. If you have any questions don't hesitate to reach out to us.

## Table of contents

* [Gettings started](#getting-started)
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

## Assignment

Your assignment is to update an existing .NET console application that presents a product catalog in text form. Currently the functionality of this application is very limited and it needs to be extended.

Included in this package you have `products.json` which is a list of products that the application should read. 

We also expect you to explain your thoughts on technical decisions you make, either through a text document or through  git commit messages.

### Some assumptions that can be made

* All prices specified in `products.json` are in USD
* You can change any file you want to
* You can use third-party nuget packages

## Requirements

* Read all products from the `products.json` file
* Cache the products you have read so the application doesn't need to read it from disk again.
* Implement any method that today throws an `NotImplementedException`
* When displaying the products, the prices should be shown with the selected currency
* The user should have the option to change currency (in runtime)
* If another currency than USD is selected the prices should be converted (e.g. 100 USD == 838 SEK)
* An option to list products in chunk of 5 (`ProductListVisualizer.cs`)
* An option to list all products grouped in 100 "currency" segments (`ProductListVisualizer.cs`) e.g.
```
0-100 SEK
    Product A 75 SEK
    Product B 100 SEK

200-300 SEK
    Product C 205 SEK
    Product D 285 SEK

...

1500-1600 SEK
    Product X 1565 SEK
    Product Y 1595 SEK

```

### Sample currency exchange rate matrix from USD to X

| Currency code | Exchange rate |
| ------------- | ------------- |
| USD           | 1.0           |
| GBP           | 0.71          |
| SEK           | 8.38          |
| DKK           | 6.06          |

## Submitting

When you feel ready to submit your work: Push your commits and send us the link to your fork at Github (_No need for a pull request to our repository_). Then we'll book a time for a review with your contact at Avensia and one of our backend developers.

If you have any question, don't hesitate to contact us.

Good luck!
