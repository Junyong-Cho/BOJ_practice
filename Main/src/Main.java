import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	static int n, l, left, right, t;
	static int window[][];
	
	public static void main(String args[]) throws IOException{
		n = nex();
		l = nex();
		window = new int[n][2];
		window[0][0] = nex();
		bw.write(window[0][0]+" ");
		for(int i = 1; i < l; i++) {
			t = nex();
			if(window[left][0]>t) {
				left = right = i;
				window[left][0] = t;
				window[left][1] = i;
			}
			else if(window[right][0]<t) {
				window[++right][0] = t;
				window[right][1] = i;
			}
			else
				binarySearch(i);
			bw.write(window[left][0]+" ");
		}
		for(int i = l; i < n; i++) {
			t = nex();
			if(window[left][0]>t) {
				left = right = i;
				window[left][0] = t;
				window[left][1] = i;
			}
			else if(window[right][0]<t) {
				window[++right][0] = t;
				window[right][1] = i;
			}
			else
				binarySearch(i);
			while(window[left][1]<i-l+1) left++;
			bw.write(window[left][0]+" ");
		}
		
		bw.flush();
	}
	
	static void binarySearch(int index) {
		int l = left, r = right;
		while(true) {
			int mid = (l+r)>>1;
			if(window[mid][0]==t) {
				window[mid][1] = index;
				right = mid;
				return;
			}
			if(t<window[mid][0])
				r = mid;
			else if(t<window[mid+1][0]) {
				right = mid+1;
				window[right][0] = t;
				window[right][1] = index;
				return;
			}
			else
				l = mid;
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
