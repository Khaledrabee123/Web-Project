// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Get references to the elements
const priceElement = document.getElementById('price');
const availabilityElement = document.getElementById('availability');
const buyButton = document.getElementById('buy-button');

// Example: Update the price
priceElement.textContent = 'Updated Price: $19999';

// Example: Change the availability
availabilityElement.textContent = 'Out of Stock';

// Example: Add a click event listener to the button
buyButton.addEventListener('click', () => {
    alert('Product added to cart!');
});