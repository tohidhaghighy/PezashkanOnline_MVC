/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
   
    config.toolbarGroups = [
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'links', groups: ['links'] },
        { name: 'others', groups: ['others'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors' },
        { name: 'about' }
    ];

    // tanzimate marbut be foxy file manager
    var roxyFileman = '/Scripts/RoxyFileManager/index.html?integration=ckeditor';
    config.filebrowserBrowseUrl = roxyFileman;
    config.filebrowserImageBrowseUrl = roxyFileman + '&type=image';
    config.removeDialogTabs = 'link:upload;image:upload';
    //-----------------------

    // tanzimate marbut be drag and drop
    config.extraPlugins = 'uploadimage';
    config.uploadUrl = '/Home/CkUploaddraganddrop';
    //---------------------------------------
    config.extraPlugins = 'codesnippet';
    config.codeSnippet_theme = 'github';
    config.extraPlugins = 'prism';
    config.format_tags = 'p;h1;h2;h3;pre';
    config.language = "fa";
    // tanzimate marbut be upload ba uploader
    config.filebrowserImageUploadUrl = '/Home/CkUpload';
    //------------------------------
    //config.filebrowserBrowseUrl = '/News/CkUpload';
    config.height = '500px';
    CKEDITOR.dtd.$removeEmpty['i'] = false;
    CKEDITOR.dtd.$removeEmpty.i = 0;
    CKEDITOR.dtd.$removeEmpty['span'] = false;
    config.contentsCss = '/assets/css/icons/fontawesome/styles.min.css';
};
