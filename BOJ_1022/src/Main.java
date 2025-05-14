import java.io.IOException;

public class Main{
	
	static public void main(String catchsunpie[]) throws IOException{
		
	}
	
	static int nex() throws IOException{
		int n,c;
		boolean pos = true;
		while((n = System.in.read())<=' ');
		if(n=='-') {
			n = System.in.read();
			pos = false;
		}
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return pos?n:~n+1;
	}
}