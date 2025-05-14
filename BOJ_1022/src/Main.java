import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static int r1,c2,r2,rc, grid[][];
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	
	static public void main(String catchsunpie[]) throws IOException{
		
	}
	
	static int nex() throws IOException{
		int n,c;
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
