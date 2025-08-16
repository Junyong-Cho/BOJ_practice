import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_5670{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static StringBuffer ans = new StringBuffer();
	static int n;
	static String s, word[];
	static Trie trie;
	static double sum;
	
	static class Trie{
		Node root = new Node();
		
		void add(String s) {
			Node n = root;
			for(int i = 0; i < s.length(); i++) {
				n.add(s.charAt(i));
				n = n.get(s.charAt(i));
			}
			n.isEnd = true;
		}
		
		int click(String s) {
			int res = 1;
			Node n = root.get(s.charAt(0));
			for(int i = 1; i < s.length(); i++) {
				if(n.count>1||n.isEnd)
					res++;
				n = n.get(s.charAt(i));
			}
			return res;
		}
	}
	
	static class Node{
		Node child[] = new Node[26];
		boolean isEnd = false;
		int count = 0;
		void add(char c) {
			if(child[c-'a']==null) {
				child[c-'a'] = new Node();
				count++;
			}
		}
		Node get(char c) {
			return child[c-'a'];
		}
	}
	
	static public void main(String catchsunpie[]) throws IOException{
		
		while((s=br.readLine())!=null&&!s.equals("")) {
			n = Integer.parseInt(s);
			word = new String[n];
			sum = 0;
			trie = new Trie();
			for(int i = 0; i < n; i++)
				trie.add(word[i]=br.readLine());
			
			for(int i = 0; i < n; i++)
				sum += trie.click(word[i]);
			
			ans.append(String.format("%.2f\n", sum/n));
		}
		
		System.out.print(ans);
	}
}