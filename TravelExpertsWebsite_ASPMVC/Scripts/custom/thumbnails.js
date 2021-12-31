"use strict";

/* thumbnails.js    -   Photo / Description Thumbnails
 * Author: James Defant
 * Date:   Jun 6 2019
 * CPRG210 - HTML / CSS / JS / PHP project
 */

var currentIndex = 0;

let imageArray = [];

// Called in body.onLoad()
function init() {

  // Instantiate img objects
  initImgArray();

  // Create table
  createThumbnailTable();

  // Display first image in array
  displayImage( 0 );

}

// Initialize image array
function initImgArray() {

  var fileArray = [
    "tokyo_ja",
    "antigua_gu3",
    "vancouver_ca",
    "islamujeres_mx"
  ];

  for(var i = 0; i < fileArray.length; i++) {

    var img = new Image();
    img.src = "img/" + fileArray[ i ] + ".jpg";
    img.classList.add( "card-img-top" );
    console.log("img: " + i + " " + img);
    imageArray.push( img );
  }
}

// Return array of Descriptions
function getDescriptionArray() {
  
  return [
            "Tokyo, JAPAN",
            "Antigua, GUATEMALA",
            "Vancouver, CANADA",
            "Isla Mujeres, MEXICO"
           ];
}

// Return array of URLs
function getURLArray() {
  
  return [
            "https://wikitravel.org/en/Tokyo",
            "https://wikitravel.org/en/Antigua_Guatemala",
            "https://wikitravel.org/en/Vancouver",
            "https://wikitravel.org/en/Isla_Mujeres"
          ];
}

// Dynamically create rows and cells
function createThumbnailTable() {
  
  // Get the pointer to the table
  var table = document.getElementById( "thumbnail_descriptions" );
  
  console.log("table = " + table);
  
  // Loop over the image array
  for(var i = 0; i < getDescriptionArray().length; i++) {
    
    // Create table row
    var row = document.createElement( "tr" );
    
    // Create table cell
    var cell = document.createElement( "td" );
    cell.setAttribute( "onmouseover", "displayImage(" + i + ")" );
    
    // Create description text
    var content = document.createTextNode( getDescriptionArray()[i] );
    
    // Append text->cell, cell->row, row->table
    cell.appendChild( content );
    row.appendChild( cell );
    table.appendChild( row );
  }
}

// Function called when onmouseover event is raised 
function displayImage( index ) {
  
  var thumbnail = document.getElementById( "thumbnail" );
  var title = document.getElementById( "card_title" );


  // Remove old picture
  if(thumbnail.hasChildNodes()) {
    thumbnail.removeChild( thumbnail.firstChild );
  }
  
  // Display new picture
  thumbnail.appendChild( imageArray[ index ] );
  thumbnail.setAttribute( "onclick", "displayPopupWindow(" + index + ")" );

  // Set the title
  title.innerHTML = getDescriptionArray()[ index ];
  
}

// Show popup window when image clicked
function displayPopupWindow( index ) {
  
  var url = getURLArray()[ index ];
  
  // Open window and go to website
  var popup = window.open( url, "", "width=600,height=500" );
  

  // Start timer
  // Wait a few seconds
  // Close the window
  setTimeout(
    function(){ 
      popup.close()
    }
    , 3000
  );
  
  

  
  
}