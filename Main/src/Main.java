import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	
	static int n, inorder[], postorder[];
	static Node nodes[], root;
	static class Node{
		int val, inIdx, postIdx;
		Node left, right;
		Node(int i){
			val = i;
		}
	}
	
	public static void main(String args[]) throws IOException{
		n = nex();
		inorder	= new int[n];
		postorder = new int[n];
		nodes = new Node[n+1];
		
		for(int i = 1; i <= n; i++)
			nodes[i] = new Node(i);
		
		for(int i = 0; i < n; i++) {
			inorder[i] = nex();
			nodes[inorder[i]].inIdx = i;
		}
		
		for(int i = 0; i < n; i++) {
			postorder[i] = nex();
			nodes[postorder[i]].postIdx = i;
		}
		
		root = nodes[postorder[n-1]];
		
		
		
		preorder(root);
	}
	
	static void preorder(Node n) throws IOException{
		if(n!=null) {
			bw.write(n.val+" ");
			preorder(n.left);
			preorder(n.right);
		}
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
