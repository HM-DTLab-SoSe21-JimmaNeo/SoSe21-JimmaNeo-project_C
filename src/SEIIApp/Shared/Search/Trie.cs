using System.Collections.Generic;
using System;
using System.Text;

namespace SEIIApp.Server.Search
{
    public class Trie
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children { get; set; }
            public char c;
            public bool isWord;

            public TrieNode(char c)
            {
                this.c = c;
                children = new Dictionary<char, TrieNode>();
            }

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }

            public void insert(String word)
            {
                char firstChar = word[0];
                TrieNode child = children.GetValueOrDefault(firstChar);
                
                if (string.IsNullOrEmpty(word)) return;
                if (child == null)
                {
                    child = new TrieNode(firstChar);
                    children.Add(firstChar, child);
                }

                if (word.Length > 1) child.insert(word.Substring(1));
                else child.isWord = true;
            }
        }

        private TrieNode root;

        public Trie(List<String> words)
        {
            root = new TrieNode();
            foreach (var word in words) root.insert(word);
        }

        public bool find(String prefix, bool exact)
        {
            TrieNode lastNode = root;
            foreach (var c in prefix.ToCharArray())
            {
                lastNode = lastNode.children[c];
                if (lastNode == null) return false;
            }

            return !exact || lastNode.isWord;
        }

        public bool find(String prefix)
        {
            return find(prefix, false);
        }

        public void suggestionHelper(TrieNode root, List<String> list, StringBuilder current)
        {
            if (root.isWord) list.Add(current.ToString());
            if (root.children == null || root.children.Count == 0) return;
            foreach (var child in root.children.Values)
            {
                suggestionHelper(child, list, current.Append(child.c));
                current.Length -= 1;
            }
        }

        public List<String> suggest(String prefix)
        {
            List<String> list = new List<String>();
            TrieNode lastNode = root;
            StringBuilder current = new StringBuilder();

            foreach (var c in prefix.ToCharArray())
            {
                lastNode = lastNode.children.GetValueOrDefault(c);
                if (lastNode == null) return list;
                current.Append(c);
            }
            suggestionHelper(lastNode, list, current);
            return list;
        }
    }
}

