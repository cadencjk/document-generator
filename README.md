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

![diagram_cropped](https://github.com/cadencjk/document-generator/assets/63772723/fb149bcd-477e-4427-a378-cbb7039f8970)


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

![Screenshot 2023-08-08 181758](https://github.com/cadencjk/document-generator/assets/63772723/d393b467-5484-47eb-bff3-faa4b72a6f75)



For different sections to be recognized by the application, please ensure that the style is a “Heading” Style in Microsoft Word.

![Screenshot 2023-08-08 181920](https://github.com/cadencjk/document-generator/assets/63772723/246e8c0c-7fda-46b9-9189-018e435bd109)



### Edit your own template
To customize your own document, choose “Upload your custom Word Document Template” followed by clicking the source button on the right side. The only format available is .docx. Click “Next” when done.

![Screenshot 2023-08-08 182014](https://github.com/cadencjk/document-generator/assets/63772723/65d3b3fa-6298-43f2-8068-fccf2d8c2422)



If your template contains the correct placeholder prerequisite, it will show up in this page. You should replace these placeholders with the corresponding values in the “Value” column. Note that the values cannot be left blank.

![Screenshot 2023-08-08 182111](https://github.com/cadencjk/document-generator/assets/63772723/177d301c-2636-4627-8d99-27d4f9fd10b9)



Click on “Filter sections from current document” if you wish to select the sections in this template. Else, click “Insert sections from other documents” if you wish to import sections from other Word Documents.
Fill up your preferred output path, then click “Select Sections”. A section tree should show up in the box below. You may select the sections and subsections you wish to filter.

![Screenshot 2023-08-08 182226](https://github.com/cadencjk/document-generator/assets/63772723/1500fb85-8108-4ae9-a051-4a8812ab0a88)



Click “Generate” and your file should be exported to your desired output path. It should not take more than 1 second to generate per document.

### Create a new template
If you wish to insert sections to a new cover page, click on “Create a new template” in the application. Click “Next” when completed.

![Screenshot 2023-08-08 182346](https://github.com/cadencjk/document-generator/assets/63772723/4d98a1f8-061f-448f-bc9e-133fda85fe02)


Fill up the corresponding placeholder values as described earlier.

Click on “Insert sections from other documents”, fill up the input/output path boxes and click “Select Sections”. Your input folder can contain multiple Word Document files.

![Screenshot 2023-08-08 182514](https://github.com/cadencjk/document-generator/assets/63772723/21ce9128-e097-42d7-b36c-b2465c5c5acc)



Click “Generate” and your files should be exported to your desired output path. It should not take more than 1 second to generate per document.

### Backup and Restore Placeholders Values
If you wish to save the values you have typed in for the placeholders, check the “Save this template” box and choose an output location in the file box. The file (.xml) will be saved to your desired location upon clicking “Next”.

![Screenshot 2023-08-08 182721](https://github.com/cadencjk/document-generator/assets/63772723/45e38ee2-b515-436e-9615-b0f8a4f4b0d7)



Alternatively, if you wish to restore a previously saved file, click the “Restore” button at the top right-hand corner of the table. Choose an appropriate file (.xml) and your values will be loaded back. 

![Screenshot 2023-08-08 182806](https://github.com/cadencjk/document-generator/assets/63772723/b6ff65f1-7fd6-4c70-bec0-88bd9dbcc542)

<p align="right">(<a href="#top">back to top</a>)</p>

## Customization
You can customize some settings for your accessibility. Navigate to “Config > ConfigGenerator.xml” and edit in your favorite text editor.

![Screenshot 2023-08-08 183052](https://github.com/cadencjk/document-generator/assets/63772723/237647c9-7319-45ec-a6e5-7c004203908b)


In the XML file, you can choose your opening and closing placeholders. By default, this is set to ‘{’ and ‘}’. Please do not use the same character for both.
You can also customize your path for quicker accessibility when selecting the files and folders.

<p align="right">(<a href="#top">back to top</a>)</p>

Enjoy!
