// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// TESTAR LITE// DR
/* 
The following JS gets the audio element and sets the start volume for the main Star Wars theme.
*/

window.onload = function () {
    var backgroundAudio = document.getElementById("bgAudio");

    backgroundAudio.volume = 0.1;

    // second seek to the specific time you're looking for
    // backgroundAudio.currentTime = 0;
}
