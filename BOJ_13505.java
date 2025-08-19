import java.io.IOException;

public class BOJ_13505 {
	
	static int n, a[], len, ans;
	static String s[];
	static Trie trie = new Trie();
	
	static class Trie{
		Node root = new Node();
		
		void add(String s) {
			Node n = root;
			for(int i = 0; i < len; i++) {
				int t = s.charAt(i)&0b1111;
				if(n.child[t]==null)
					n.child[t] = new Node();
				n = n.child[t];
			}
		}
		
		int xor(String s) {
			Node n = root;
			int res = 0;
			for(int i = 0; i < len; i++) {
				int t = s.charAt(i)&0b1111;
				res<<=1;
				if(n.child[(t+1)%2]!=null) {
					res++;
					n = n.child[(t+1)%2];
				}
				else {
					n = n.child[t];
				}
			}
			
			return res;
		}
	}
	
	static class Node{
		Node child[] = new Node[2];
	}
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		
		a = new int[n];
		
		for(int i = 0; i < n; i++)
			len = max(len,a[i]=nex());
		
		s = new String[n];
		
		len = len(len);
		
		for(int i = 0; i < n; i++) {
			s[i] = Integer.toBinaryString(a[i]);
			s[i] = "0".repeat(len-s[i].length())+s[i];
		}
		
		trie.add(s[0]);
		
		for(int i = 1; i < n; i++) {
			ans = max(ans,trie.xor(s[i]));
			trie.add(s[i]);
		}
		
		System.out.print(ans);
	}
	
	static int len(int i) {
		int res = 0;
		while(i>0) {
			i>>=1;
			res++;
		}
		return res;
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}

}
