/**
 * This is the entry file where you start your magic.
 *
 * It's currently a .js-file but feel free to use TypeScript
 * instead if you're comfortable with it.
 *
 * To transpile you just need to type `$ npm start` or `$ yarn start`. This
 * will start the mocked API server and bundling.
 */

const container = document.createElement('div');
document.body.appendChild(container);

// NOTE: The code below is just to make sure everything is working fine

container.innerText = 'Loading...';

fetch('http://localhost:8181/products', {credentials:'include'})
  .then(
    response =>
      response.ok
        ? response.json()
        : Promise.reject(`Cannot communicate with the mocked REST API server (${response.statusText})`),
  )
  .then(products => {
    container.innerText = "It's working!\n\n";
    container.innerText += 'Found sample products:\n';
    products.forEach(product => (container.innerText += `- ${product.title}\n`));
  })
  .catch(error => {
    container.innerText = `Error: ${error}`;
  });
