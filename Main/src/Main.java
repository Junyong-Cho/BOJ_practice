import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	static int n, l, left, right;
	static int window[][];
	
	public static void main(String args[]) throws IOException{
		System.out.println("hello world "+ nex());
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
