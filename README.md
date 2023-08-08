<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/cadencjk/document-generator">
    <img src="Resources/logo.png" alt="Logo" width="128" height="128">
  </a>

<h1 align="center">Document Generator</h3>

  <p align="center">
  An application designed to automate the process of generating different reports from a single base document.
    <br />
    <a href="#getting-started"><strong>Read the installation guide »</strong></a>
    <br />
    <a href="#features"><strong>View the features »</strong></a>
  </p>
</div>

<!-- ABOUT THE PROJECT -->
### About The Project
The main function of this application is to replace placeholders and filter sections from your document, speeding up the process of customizing your report for different clients. 

<p align="right">(<a href="#top">back to top</a>)</p>

### Features

This application generates different documents based on your requirements by enabling these 2 features.
1) Replace placeholders in document
2) Filter sections from document

![diagram_cropped](https://github.com/cadencjk/document-generator/assets/63772723/e9bb4afa-f206-40f0-983c-7f5dd3c90c24)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

This .exe application can only be run on Windows. You may run it on Mac using this <a href="https://www.wikihow.com/Open-Exe-Files-on-Mac"><strong>instruction</strong></a>, but there is no gurantee that it will work.

### Installation

1. Download the zip file from <a href="https://github.com/cadencjk/document-generator"><strong>here</strong></a>
   
2. Unzip the file to your preferred location

3. Double click on DocumentGenerator.exe

4. Your application should start running!
<p align="right">(<a href="#top">back to top</a>)</p>


## Usage
For the placeholders you wish to replace in your document, please enclose your placeholders with the following brackets ‘{ ’  and ‘ }’. You can add placeholders in your header and footer as well.

For different sections to be recognized by the application, please ensure that the style is a “Heading” Style in Microsoft Word.


### Edit your own template
To customize your own document, choose “Upload your custom Word Document Template” followed by clicking the source button on the right side. The only format available is .docx. Click “Next” when done.

If your template contains the correct placeholder prerequisite, it will show up in this page. You should replace these placeholders with the corresponding values in the “Value” column. Note that the values cannot be left blank.

Click on “Filter sections from current document” if you wish to select the sections in this template. Else, click “Insert sections from other documents” if you wish to import sections from other Word Documents.
Fill up your preferred output path, then click “Select Sections”. A section tree should show up in the box below. You may select the sections and subsections you wish to filter.

Click “Generate” and your file should be exported to your desired output path. It should not take more than 1 second to generate per document.

### Create a new template
If you wish to insert sections to a new cover page, click on “Create a new template” in the application. Click “Next” when completed.

Fill up the corresponding placeholder values as described earlier.

Click on “Insert sections from other documents”, fill up the input/output path boxes and click “Select Sections”. Your input folder can contain multiple Word Document files.

Click “Generate” and your files should be exported to your desired output path. It should not take more than 1 second to generate per document.

### Backup and Restore Placeholders Values
If you wish to save the values you have typed in for the placeholders, check the “Save this template” box and choose an output location in the file box. The file (.xml) will be saved to your desired location upon clicking “Next”.

Alternatively, if you wish to restore a previously saved file, click the “Restore” button at the top right-hand corner of the table. Choose an appropriate file (.xml) and your values will be loaded back. 




Enjoy!

