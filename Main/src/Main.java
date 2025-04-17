import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	static int n, l, left, right;
	static int window[][];
	
	public static void main(String args[]) throws IOException{
		n = nex();
		l = nex();
		window = new int[n][2];
		window[0][0] = nex();
		bw.write(window[0][0]+" ");
		for(int i = 1; i < n; i++) {
			int t = nex();
			if(window[left][0]>t) {
				left = right = i;
				window[left][0] = t;
				window[left][1] = i;
			}
			else if(window[right][0]>t);
			bw.write(window[left][0]+" ");
		}
	}
	
	static int nex() throws IOException{
		int n, c;
		boolean pos = true;
		while((n = System.in.read())<=' ');
		if(n=='-') {
			pos = false;
			n = System.in.read();
		}
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return pos?n:~n+1;
	}
}
