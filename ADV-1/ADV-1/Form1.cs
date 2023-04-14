namespace ADV_1
{
    public partial class Form1 : Form
    {
        /*
        Word Suggestions - Consider a text box, such as a search entry box, that accepts a word or a phrase, and for each typed word gives you suggestions 
        as to what the word might be as you type it - easy-peasy, right? Just your plain ol' word completion Trie exercise... a twist though, which I'm sure 
        won't be an issue - I'd like the suggestions to find a possible match even if the word is misspelled - for instance, if I type in "areport", I probably 
        meant "airport"; same for "hairport", or even "hareport" - you get the idea. There should be a clear indication when the word is an exact match, (completion) 
        vs when it's a suggestion. Of course, if I type in "sdfgds", it's reasonable to have a return value of 😢 - there's just no way to do much with that garbage input. 
        */

        public Form1()
        {
            InitializeComponent();
        }
    }
}